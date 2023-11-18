namespace Resturants.Application.Contracts.ResturantApp.Dtos
{
    public class ResturantDto
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
    
        public MenuDto Menu { get; set; } = new MenuDto();
    }
}
