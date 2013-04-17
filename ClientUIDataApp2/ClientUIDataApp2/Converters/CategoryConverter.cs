using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using ClientUIDataApp2.ModelServices;
using ClientUIDataApp2.DomainModel;

namespace ClientUIDataApp2.Converters
{
    public class CategoryConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            CategoriesRepository repository = CategoriesRepository.Instance as CategoriesRepository;

            if (repository != null && value != null)
            {
                int categoryID = (int)value;
                Category category = repository.EntitySet.Where(c => c.CategoryID == categoryID).FirstOrDefault();

                if (category != null)
                    return category.CategoryName;
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


}
