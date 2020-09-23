using JsonMultiConverter.Handlers;
using JsonMultiConverter.Interfaces;
using JsonMultiConverter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonMultiConverter.Strategy
{
    class ContextStrategy
    {
        private IStrategy _strategy;
        public ContextStrategy()
        { }
        public ContextStrategy(IStrategy strategy)
        {
            this._strategy = strategy;
        }
        public void SetStrategy(IStrategy strategy)
        {
            this._strategy = strategy;
        }

        public List<BasePolicy> DoSomeBusinessLogic(AbstractHandler handler, string[] selectableJson, int quantity)
        {
            List<BasePolicy> basePolicies = new List<BasePolicy>();
            Random rand = new Random();
            for (int i = 0; i < quantity; i++)
            {
                var jsonType = (IJsonType)handler.Handle(selectableJson[rand.Next(0, selectableJson.Length)]);
                if (handler.errors != null)
                {
                    foreach (var item in handler.errors)
                        Console.WriteLine(item.ToString());
                }
                if (jsonType is null)
                    Console.WriteLine("Ошибка конвертации для № " + quantity.ToString());
                else
                    basePolicies.Add(_strategy.BasePolicyCreatorFromJson(jsonType));
            }
            return basePolicies;
        }
        public List<BasePolicy> DoSomeBusinessLogic(AbstractHandler handler, string json, int quantity)
        {
            List<BasePolicy> basePolicies = new List<BasePolicy>();
            for (int i = 0; i < quantity; i++)
            {
                var jsonType = (IJsonType)handler.Handle(json);
                if (handler.errors != null)
                {
                    foreach (var item in handler.errors)
                        Console.WriteLine(item.ToString());
                }
                if (jsonType is null)
                    Console.WriteLine("Ошибка конвертации для № " + quantity.ToString());
                else
                    basePolicies.Add(_strategy.BasePolicyCreatorFromJson(jsonType));
            }
            return basePolicies;
        }
    }
}
