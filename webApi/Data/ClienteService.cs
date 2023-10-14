
public class ClienteService
{
    private readonly DataAccessLayer _dataAccessLayer;

    public ClienteService(DataAccessLayer dataAccessLayer)
    {
        _dataAccessLayer = dataAccessLayer;
    }

    public async Task<Usuario> CrearUsuario(Usuario usuario)
    {
        // Valida el correo electrónico
        if (!ValidarCorreoElectronico(usuario.CorreoElectronico))
        {
            throw new ArgumentException("El correo electrónico no es válido");
        }

        // Crea un nuevo usuario
        _dataAccessLayer.CrearUsuario(usuario);

        // Devuelve el usuario
        return usuario;
    }

    private bool ValidarCorreoElectronico(string correoElectronico)
    {
        // Valida el correo electrónico
        return Regex.IsMatch(correoElectronico, "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,6}$");
    }
}
