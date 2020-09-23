using System;
using Newtonsoft.Json;
using JsonMultiConverter.Models;
using JsonMultiConverter.Handlers;
using AutoMapper;
using JsonMultiConverter.Mapping;
using JsonMultiConverter.Contexts;

namespace JsonMultiConverter
{
    class Program
    {
        readonly static string json0 = @"{
        'DocumentDate': '2016-06-06',
        'EffectiveDate': '2016-06-06',
	    'ExpirationDate': '2017-06-06',
	    'AcceptationDate': '2016-06-06',
	    'Insurer': {
		    'Name': 'Петрищенко Федор'
            },
	    'Vehicle': {
		    'MarkName': 'Volvo',
		    'ModelName': 'XC90'
            }
        }";

        readonly static string json1 = @"{
	    'Insurer': {
		    'FirstName': 'Петрищенко',
		    'LastName': 'Федор'
            },
	    'Vehicle': {
		    'Mark': 'Volvo',
		    'Model': 'XC90'
            },
	    'DateBegin': '2016-06-06',
	    'DateEnd': '2017-06-05'
        }";

        readonly static string json2 = @"{
	    'InsurerFirstName': 'Петрищенко',
	    'InsurerLastName': 'Федор',
	    'Vehicle': {
		    'Mark': 'Volvo',
		    'Model': 'XC90'
            },
	    'EffectiveDate': '2016-06-06',
	    'ExpirationDate': '2017-06-05'
        }";

        readonly static string json3 = @"{
	    'Insurer': {
		'Type': 'Person',
		'Person': {
			'InsurerFirstName': 'Петрищенко',
			'InsurerLastName': 'Федор'
            }
	    },
	    'VehicleMark': 'Volvo',
	    'VehicleModel': 'XC90',
	    'DateBegin': '2016-06-06',
	    'DateEnd': '2017-06-05'
        }";

        static int jsonType;
        static bool JsonTypeChoose()
        {
            Console.WriteLine("Введите тип json (0, 1, 2, 3, 4):");
            if (!int.TryParse(Console.ReadLine(), out jsonType))
            {
                Console.WriteLine("Не верно введен тип json");
                return false;
            }
            if ((jsonType < 0) || (jsonType > 4))
            {
                Console.WriteLine("Не верно введен тип json");
                return false;
            }
            return true;
        }
        static Mapper mapper;
        private static void AutoMapperConfigure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<JsonMapping>();
            });
            mapper = new Mapper(config);
        }
        static void Main(string[] args)
        {
            try
            {
                AutoMapperConfigure();                
                var baseType = new BaseTypeHandler();
                var firstType = new FirstTypeHandler();
                var secondType = new SecondTypeHandler();
                var thirdType = new ThirdTypeHandler();
                BasePolicy basePolicies = new BasePolicy();
                Context context;
                while (!JsonTypeChoose())
                { }
                
                switch (jsonType)
                {
                    case 0:
                        context = new Context(baseType, mapper);
                        basePolicies = context.ReturnBaseObject(json0);
                        break;
                    case 1:
                        context = new Context(firstType, mapper);
                        basePolicies = context.ReturnBaseObject(json1);
                        break;
                    case 2:
                        context = new Context(secondType, mapper);
                        basePolicies = context.ReturnBaseObject(json2);
                        break;
                    case 3:
                        context = new Context(thirdType, mapper);
                        basePolicies = context.ReturnBaseObject(json3);
                        break;
                    case 4: // Тип не определен и определяется в зависимости от переданного json
                        baseType.SetNext(firstType).SetNext(secondType).SetNext(thirdType);
                        string[] selectableJson = new string[4] { json0, json1, json2, json3 };
                        Random rand = new Random();

                        context = new Context(baseType, mapper);
                        basePolicies = context.ReturnBaseObject(selectableJson[rand.Next(0, selectableJson.Length)]);                        
                        break;
                }
                Console.WriteLine(JsonConvert.SerializeObject(basePolicies));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
