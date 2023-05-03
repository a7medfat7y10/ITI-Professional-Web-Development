using Microsoft.AspNetCore.Components;
using SharedLiberary;

namespace Task1.Pages
{
    public partial class TraineeDetails
    {
        [Parameter]
        public int ID { get; set; }

        public Trainee? CurTrainee { get; set; }

        protected override Task OnInitializedAsync()
        {
            CurTrainee = MockData.trainees.FirstOrDefault(em => em.ID == ID);

            return base.OnInitializedAsync();
        }
    }
}
