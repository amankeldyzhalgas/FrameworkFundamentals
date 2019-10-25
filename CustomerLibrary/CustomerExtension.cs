using System;
using System.Globalization;

namespace CustomerLibrary
{
    public class CustomerExtension : ICustomFormatter, IFormatProvider
    {
        public IFormatProvider Provider { get; private set; }

        public CustomerExtension(IFormatProvider provider = null)
        {
            Provider = provider ?? CultureInfo.CurrentCulture;
        }

        public object GetFormat(Type formatType)
        {
            return formatType == typeof(ICustomFormatter) ? this : null;
        }
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
            {
                format = "NC";
            }
            if (formatProvider is null)
            {
                formatProvider = Provider;
            }
            if (format != "NC")
            {
                return string.Format(formatProvider, "{0:" + format + "}", arg);
            }
            if (arg is null)
            {
                throw new ArgumentNullException($"{nameof(arg)} shouldn' t be null.");
            }
            if (arg.GetType() != typeof(Customer))
            {
                throw new ArgumentException($"The format of '{format}' is invalid.");
            }
            Customer customer = (Customer)arg;
            return String.Format("Customer record: {0}, {1}", customer.Name, customer.ContactPhone);
        }
    }
}
