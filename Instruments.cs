using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masterpol
{
    internal class Instruments
    {
        public int CalculateMaterialRequirement(
            int productTypeId,
            int materialTypeId,
            int productQuantity,
            double parameter1,
            double parameter2)
        {
            Models.Database Database = new Models.Database();
            // Проверяем, что параметры продукции положительные числа
            if (productQuantity <= 0 || parameter1 <= 0 || parameter2 <= 0)
            {
                return -1;
            }

            // Ищем тип продукции и тип материала по ID
            var productType = Database.product_type.FirstOrDefault(pt => pt.id == productTypeId);
            var materialType = Database.material_type.FirstOrDefault(mt => mt.id == materialTypeId);

            // Проверка на существование указанных типов продукции и материала
            if (productType == null || materialType == null || productType.product_type_ratio == null || materialType.reject_rate == null)
            {
                return -1;
            }

            // Расчёт базового количества материала на единицу продукции
            double baseMaterialPerProduct = parameter1 * parameter2 * (double)productType.product_type_ratio;

            // Расчёт общего количества материала для всех единиц продукции
            double totalMaterialRequired = baseMaterialPerProduct * productQuantity;

            // Увеличиваем на процент брака материала
            double rejectRate = (double)materialType.reject_rate;
            double materialWithReject = totalMaterialRequired * (1 + rejectRate / 100);

            // Округляем до целого числа и возвращаем результат
            return (int)Math.Ceiling(materialWithReject);
        }
    }
}
