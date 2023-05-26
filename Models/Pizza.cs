using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;

namespace Projet_Web_Pizza.Models
{
    public class Pizza
    {
        [JsonIgnore]
        public int PizzaID { get; set; }

        [Display(Name = "Nom")]
        public string nom { get; set; }

        [Display(Name = "Prix (€)")]
        public int prix { get; set; }

        [Display(Name = "Végétarienne")]

        public bool  vegetarienne { get; set; }

        [JsonIgnore]
        [Display(Name = "Ingrédients")]
        public string ingredients { get; set; }

        [NotMapped]
        [JsonPropertyName("ingredients")]
        public string[] ListeIngredients
        {

            get 
            {
                if ((ingredients == null) || (ingredients.Count() == 0))
                {
                    return null;
                }

                return ingredients.Split(", ");
            }
        }




    }


}
