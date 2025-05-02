using Microsoft.AspNetCore.Mvc;

namespace unit_converter.Controllers
{
    public class ConversionController : Controller
    {
        Dictionary<string, float> mm = new();
        Dictionary<string, float> cm = new(); 
        Dictionary<string, float> m = new(); 
        Dictionary<string, float> km = new(); 
        Dictionary<string, float> yd = new(); 
        Dictionary<string, float> inch = new(); 
        Dictionary<string, float> ft = new(); 
        Dictionary<string, float> mi = new(); 

        public IActionResult Length(int data, string unit1, string unit2)
        {
            if (data > 0)
            {
                ViewData["Data"] = data;
                ViewData["Unit1"] = unit1;
                ViewData["Unit2"] = unit2;
                ViewData["Converted"] = true;

                ViewData["Result"] = LengthConversion(data, unit1, unit2);


            }
            else
            {
                ViewData["Converted"] = false;
            }

            return View();
        }

        public IActionResult Weight(int data, string unit1, string unit2)
        {

            if (data > 0)
            {
                ViewData["Data"] = data;
                ViewData["Unit1"] = unit1;
                ViewData["Unit2"] = unit2;
                ViewData["Converted"] = true;

                ViewData["Result"] = WeightConversion(data, unit1, unit2);


            }
            else
            {
                ViewData["Converted"] = false;
            }

            return View();
        }

        public IActionResult Temperature(int data, string unit1, string unit2)
        {
            if (data >= 0 && unit1 != null) 
            {
                ViewData["Data"] = data;
                ViewData["Unit1"] = unit1;
                ViewData["Unit2"] = unit2;
                ViewData["Converted"] = true;
                ViewData["Result"] = TemperatureConversion(data, unit1, unit2);
            }
            else
            {
                ViewData["Converted"] = false;
            }

            return View();
        }

        private float LengthConversion(float n, string unitA, string unitB)
        {
            Dictionary<string, float> factors = new()
            {
                { "mm", 0.001f },
                { "cm", 0.01f},
                { "m", 1 },
                { "k", 1000 },
                { "in", 0.0254f },
                { "ft", 0.3048f },
                { "yd", 0.9144f },
                { "mi", 1609.34f }
            };

            float valueInMeters = n * factors[unitA];
            return valueInMeters / factors[unitB];

        }

        private float WeightConversion(float n, string unitA, string unitB)
        {
            Dictionary<string, float> factors = new()
            {
                { "milligram", 0.001f },
                { "gram", 1 },
                { "kilogram", 1000 },
                { "ounce", 28.3495f },
                { "pound", 453.592f }
            };

            float valueInGrams = n * factors[unitA];
            return valueInGrams / factors[unitB];

        }

        private float TemperatureConversion(float n, string unitA, string unitB)
        {
            if (unitA == "F")
            {
                if (unitB == "C")
                {
                    float result = (n - 32) * (5/9);
                    return result;   
                }
                else if (unitB == "K")
                {
                    float result = (n - 43) * (5/9) + 273.15f;
                    return result;
                }
            }
            else if (unitA == "C")
            {
                if (unitB == "F")
                {
                    float result = n * (9/5) + 32;
                    return result;
                }
                else if (unitB == "K")
                {
                    float result = n + 273.15f;
                    return result;
                }
            }
            else if (unitA == "K")
            {
                if (unitB == "C")
                {
                    float result = n - 273.15f;
                    return result;
                }
                else if (unitB == "F")
                {
                    float result = (n - 273.15f) * (9/5) + 32;
                    return result;
                }
            }
            return 0;
        }

    }
}
