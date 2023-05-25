import React from 'react'
import { Routes, Route } from 'react-router-dom'
import Layout from './layout/Layout'
import Home from './paginas/Home';
import Cadastros from './paginas/Cadastros';
import Montagem from './paginas/Montagem';
import Util from './paginas/Util';
import Sobre from './paginas/Sobre';

// o element é quem vai renderizar a tela
function App() {
  return (
    <>
      <Routes>
        <Route path='/' element={<Layout><Home/></Layout>}/>
        <Route path='/cadastros' element={<Layout><Cadastros/></Layout>}/>
        <Route path='/montagem' element={<Layout><Montagem/></Layout>}/>
        <Route path='/util' element={<Layout><Util/></Layout>}/>
        <Route path='/sobre' element={<Layout><Sobre/></Layout>}/>
      </Routes>
    </>
  );
}

export default App;
