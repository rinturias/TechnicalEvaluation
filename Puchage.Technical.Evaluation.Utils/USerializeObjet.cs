using Newtonsoft.Json;
using System;

namespace Puchage.Technical.Evaluation.Utils
{
    public class USerializeObjet
    {
        public static dynamic ConvertObjet<dynamic>(dynamic obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var test = JsonConvert.DeserializeObject<dynamic>(json);
            return test;
        }
    }
}
