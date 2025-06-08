public class UsuarioGSService
{
    private readonly AppDbContext _context;

    public UsuarioGSService(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<UsuarioGSReadDTO> GetAll()
    {
        return _context.Usuarios
            .Select(u => new UsuarioGSReadDTO
            {
                IdUsuario = u.IdUsuario,
                Nome = u.Nome,
                Email = u.Email
            })
            .ToList();
    }

    public void Create(UsuarioGSCreateDTO dto)
    {
        var usuario = new UsuarioGS
        {
            Nome = dto.Nome,
            Telefone = dto.Telefone,
            TelefoneEmergencia = dto.TelefoneEmergencia,
            Email = dto.Email,
            Senha = dto.Senha
        };

        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
    }

    public bool Update(int id, UsuarioGSCreateDTO dto)
    {
        var usuario = _context.Usuarios.Find(id);
        if (usuario == null)
            return false;

        usuario.Nome = dto.Nome;
        usuario.Telefone = dto.Telefone;
        usuario.TelefoneEmergencia = dto.TelefoneEmergencia;
        usuario.Email = dto.Email;
        usuario.Senha = dto.Senha;

        _context.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        var usuario = _context.Usuarios.Find(id);
        if (usuario == null)
            return false;

        _context.Usuarios.Remove(usuario);
        _context.SaveChanges();
        return true;
    }
}
