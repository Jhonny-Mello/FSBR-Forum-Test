import { useAuth } from "../Services/AuthApi/useAuth";

interface Props {}

const Navbar = (props: Props) => {
      const {logout} = useAuth();
    return (
      <>
        <div id="sidebar">
          <div>
            {/* <form id="search-form" role="search">
              <input
                id="q"
                aria-label="Search contacts"
                placeholder="Search"
                type="search"
                name="q"
              />
              <div
                id="search-spinner"
                aria-hidden
                hidden={true}
              />
              <div
                className="sr-only"
                aria-live="polite"
              ></div>
            </form> */}
          </div>
          <nav>
            <ul>
              <li>
                <a href={`/Home`} onClick={() => {
                }}>Home</a>
              </li>
              <li>
                <a href={`/Posts`} onClick={() => {
                }}>Fórum</a>
              </li>
              <li>
                <a href={`/Add/Post`} onClick={() => {
                }}>Nova Postagem</a>
              </li>
            </ul>
          </nav>
          <div>
            <h6 onClick={logout}>Sair</h6>
          </div>
        </div>
      </>
    );
  }

export default Navbar;
  