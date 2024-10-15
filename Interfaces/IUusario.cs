    public interface IUsuarioService
    {
        public IEnumerable<Usuario> GetAll();
        public Usuario? GetById(int id);
        public Usuario Create(UsuarioDTO u);
        public void Delete(int id);
        public Usuario? Update(int id, Usuario a);

    }