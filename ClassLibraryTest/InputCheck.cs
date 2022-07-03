using System;

namespace ClassLibraryTest
{
    public class InputCheck
    {   
        /// <summary>
        /// Проверяет вводимые значения
        /// </summary>
        /// <param name="count"></param>
        /// <returns>true/false</returns>
        public static bool ValidateInput(string count)
        {
            int num;
            bool isNumQuantity = int.TryParse(Convert.ToString(count), out num);

            if (Convert.ToString(count) != "" && isNumQuantity)
            {
                if (Convert.ToInt32(count) < 0 || Convert.ToInt32(count) > 1000)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
