namespace TestWebAPIByVSPurple.Models
{
    public class CategoryModel
    {
        public int? Id { get; set; }
        /// <summary>
        /// Tên chủng loại
        /// </summary>
        public string NameVn { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Image { get; set; }
    }
}
