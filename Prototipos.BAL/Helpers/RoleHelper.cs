namespace Prototipos.BAL.Helpers
{
    public static class RolesReferences
    {
        public const string Cocinero = "Cocinero";
        public const string Cajero = "Cajero";
        public const string Mesero = "Mesero";
        public const string Gerente = "Gerente";
        public const string Administrador = "Administrador";
        public const string ResourceOwner = "ResourceOwner";
        public const string ResourceOwnerLower = "resourceowner";
    }

    public static class ViewsByRole
    {
        public static Dictionary<string, ActionController> Dictionary = new Dictionary<string, ActionController>()
        {
            { RolesReferences.Cocinero, new ActionController("Cocina", "Index")},
            { RolesReferences.Cajero, new ActionController("Caja", "Index")},
            { RolesReferences.Mesero, new ActionController("Comedor", "Index")},
            { RolesReferences.Gerente, new ActionController("Reporte", "Index")},
            { RolesReferences.Administrador, new ActionController("Administracion", "Index")},
            { RolesReferences.ResourceOwner, new ActionController("Administracion", "Index")},
            { "default", new ActionController("Auth", "Login")}
        };
    }

    public class ActionController
    {
        public ActionController(string controller, string action)
        {
            this.Controller = controller; 
            this.Action = action;
        }

        public string Controller { get; set; }
        public string Action { get; set; }
    }
}
