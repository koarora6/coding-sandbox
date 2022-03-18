using System.ComponentModel.DataAnnotations.Schema;

namespace SportsStore.Models
{
    public class Product
    {
        public long ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        //The price prop has been decorated with the column attribute
        //to specify the SQL data type that will be used to store values
        //for this property. Not all C# types map neatly onto SQL types
        //and this attribute ensures the database uses an appropriate 
        //type for the application data
        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }
        public string Category { get; set; }

    }
}
