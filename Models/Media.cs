using Microsoft.AspNetCore.Mvc.Formatters;

namespace OC_P5.Models
{
    public class Media
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string Path { get; set; }
        public int TypeOfMediaId { get; set; }
        public ICollection<CarMedia> CarMedias { get; set; }
        public virtual TypeOfMedia TypeOfMedia { get; set; }
    }
}
