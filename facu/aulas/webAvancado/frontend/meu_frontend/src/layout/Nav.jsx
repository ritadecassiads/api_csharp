import { NavLink } from "react-router-dom";

// dizer a rota de cada link
function Nav() {
  return (
    <nav>
      <ul>
        <li>
          <NavLink to="/">Home</NavLink>
        </li>
        <li>
          <NavLink to="/cadastros">Cadastros</NavLink>
        </li>
        <li>
          <NavLink to="/montagem">Montagem</NavLink>
        </li>
        <li>
          <NavLink to="/util">Sobre</NavLink>
        </li>
        <li>
          <NavLink to="/sobre">Sobre</NavLink>
        </li>
      </ul>
    </nav>
  );
}

export default Nav;
