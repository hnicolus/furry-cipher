using System;
using MudBlazor;

namespace FuriousCipher.Wasm.Converters
{
    public class ObjectToBoolConverter : BoolConverter<object>
    {

        public ObjectToBoolConverter()
        {
            SetFunc = OnSet;
            GetFunc = OnGet;
        }

        private object OnGet(bool? value)
        {
            try
            {
                return (object)(value == true);
            }
            catch (Exception e)
            {
                UpdateGetError("Conversion error: " + e.Message);
                return default;
            }
        }
        private bool? OnSet(object arg)
        {
            if (arg == null)
                return null;
            try
            {
                if (arg is bool)
                    return (bool)(object)arg;
                else if (arg is bool?)
                    return (bool?)(object)arg;
                else
                {
                    UpdateSetError("Unable to convert to bool? from type object");
                    return null;
                }
            }
            catch (FormatException e)
            {
                UpdateSetError("Conversion error: " + e.Message);
                return null;
            }
        }
    }
}
