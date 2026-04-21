using System.ComponentModel.DataAnnotations.Schema;

namespace DataStructuresPractice.Models
{
    public abstract class ModelBase/*<TPrimaryKey>*/
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
