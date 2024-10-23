public interface IUsuarioService
{
    public IEnumerable<Usuario> GetAll();
    public Usuario? GetById(int id);
    public Usuario? GetByLogin(string login);
    public Usuario? GetByLoginAndPassword(string login, string password);
    public Usuario Create(UsuarioDTO u);
    public Usuario? Update(int id, Usuario u);
    public void Delete(int id);
}