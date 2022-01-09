using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TT_az
{
    
    [Serializable]

    public class cars
    {
        public static int counteer = 0;

        public cars()
        {
            this.CarId = ++counteer;
        }

        public int CarId { get; set; }
        public string CarName { get; set; }
        public int CarModelId { get; set; }
        public int CarMarkaId { get; set; }
        public int CarYear { get; set; }
        public double CarBanNo { get; set; }
        public double CarMotor { get; set; }
        public string CarTransmission { get; set; }
        public string CarColor { get; set; }
        public double CarPrice { get; set; }

        public override string ToString()
        {
            return $"Car Id: {CarId}\n" +
               
                $"Car: {CarName} \n" +
                
                $"Car ModelId: {CarModelId} \n" +
                
                $"Car MarkaId: {CarMarkaId} \n" +
               
                $"Car Year: {CarYear} \n" +
                
                $"Car BanNo: {CarBanNo} \n" +
                
                $"Car Motor: {CarMotor} \n" +
                
                $"Car Name: {CarName} \n" +
               
                $"Car Transmission: {CarTransmission} \n" +
                
                $"Car Color: {CarColor} \n" +
               
                $"Car Price: {CarPrice} \n" +
                $"##=============================================================##";

        }
        //public void Add(cars cars)
        //{
        //    Array.Resize(ref cars, cars.Length + 1);
        //    cars[cars.Lenght - 1] = cars;
        //}

        //public void Add(cars c)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
