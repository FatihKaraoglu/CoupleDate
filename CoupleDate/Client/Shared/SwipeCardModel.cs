using CoupleDate.Shared;
using CoupleDate.Shared.DTO;
using Microsoft.AspNetCore.Components;

namespace CoupleDate.Client.Shared
{
    public class SwipeCardModel
    {
        public int Id { get; set; }
        public RenderFragment Content { get; set; }
        public ElementReference ElementRef { get; set; }
        public bool IsVisible { get; set; } = true;
        public DateIdeaDTO DateIdea { get; set; }
    }
}
