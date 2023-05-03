using Microsoft.AspNetCore.Components;
using SharedLiberary;
using Task1.Repos;

namespace Task1.Pages
{
    public partial class TraineeDetails
    {
        [Parameter]
        public int ID { get; set; }

        public Trainee? CurTrainee { get; set; }


        [Inject]
        public ITraineeService TraineeRepo { get; set; }

        protected override async Task OnInitializedAsync()
        {
            CurTrainee = await TraineeRepo.GetTraineeDetails(ID);

        }
    }
}
