using DataAnnotationsExtensions.ClientValidation;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(Project.MODEL.App_Start.RegisterClientValidationExtensions), "Start")]
 
namespace Project.MODEL.App_Start {
    public static class RegisterClientValidationExtensions {
        public static void Start() {
            DataAnnotationsModelValidatorProviderExtensions.RegisterValidationExtensions();            
        }
    }
}