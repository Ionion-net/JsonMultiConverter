using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using JsonMultiConverter.Models;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Linq;
using JsonMultiConverter.Models.JsonModels;
using JsonMultiConverter.Interfaces;
using Newtonsoft.Json.Schema.Generation;
using JsonMultiConverter.Handlers;
using AutoMapper;
using JsonMultiConverter.Mapping;
using System.IO;
using JsonMultiConverter.Strategy;

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
        static int quantity;
        static bool JsonTypeChoose()
        {
            Console.WriteLine("Введите тип json (например:0, 1, 2, 3):");
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
            Console.WriteLine("Введите количество json файлов:");
            if (!int.TryParse(Console.ReadLine(), out quantity))
            {
                Console.WriteLine("Только цифры.");
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
                var context = new ContextStrategy();
                var baseType = new BaseTypeHandler();
                var firstType = new FirstTypeHandler();
                var secondType = new SecondTypeHandler();
                var thirdType = new ThirdTypeHandler();
                List<BasePolicy> basePolicies = new List<BasePolicy>();

                while (!JsonTypeChoose())
                { }
              
                switch (jsonType)
                {
                    case 0:
                        context.SetStrategy(new BaseTypeStrategy());
                        basePolicies = context.DoSomeBusinessLogic(baseType, json0, quantity);
                        break;
                    case 1:
                        context.SetStrategy(new FirstTypeStrategy(mapper));
                        basePolicies = context.DoSomeBusinessLogic(firstType, json1, quantity);
                        break;
                    case 2:
                        context.SetStrategy(new FirstTypeStrategy(mapper));
                        basePolicies = context.DoSomeBusinessLogic(secondType, json2, quantity);
                        break;
                    case 3:
                        context.SetStrategy(new FirstTypeStrategy(mapper));
                        basePolicies = context.DoSomeBusinessLogic(thirdType, json3, quantity);
                        break;
                    case 4:
                        baseType.SetNext(firstType).SetNext(secondType).SetNext(thirdType);
                        string[] selectableJson = new string[4] { json0, json1, json2, json3 };
                        context.SetStrategy(new FirstTypeStrategy(mapper));
                        basePolicies = context.DoSomeBusinessLogic(baseType, selectableJson, quantity);
                        break;
                }
                foreach (var item in basePolicies)
                    Console.WriteLine(item.Insurer.Name);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }

    public class PersonConverter : CustomCreationConverter<BasePolicy>
    {
        public override BasePolicy Create(Type objectType)
        {
            return new BasePolicy();
        }
    }
}
