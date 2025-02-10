using MediatR;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Laroche.FleetManager.Application.Features.Drivers.Commands
{
    public record CreateDriverCommand : IRequest<int>
    {
        public string Nom { get; set; }
        public string Prenoms { get; set; }
        public string NumeroTelephone { get; set; }
        public Date DateNaissance { get; set; }
        public string PermisConduire { get; set; }
        public Date DateEmbauche { get; set; }
    }
}
