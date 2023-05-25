import axios from "axios";
import { useState, useEffect } from 'react';

function Cadastros() {
    // terei as areas, inicio o state vazio e depois que eu fizer a requisição irá popular 'areas'
    const[areas, setAreas] = useState([])

    function getAreas(){
        // reage a requisição, pode criar um loop infinito se estiver solto
        axios.get('http://localhost:3000/areas').then((response)=>{
            setAreas(response.data)
        })
    }

    // invoca o getAreas no momento em que a tela estivar renderizada tudo
    // useEffect = depois que a pagina ta renderizada chama a função
    useEffect(getAreas, [])

    function excluirArea(id){
        axios.delete('http://localhost:3000/areas/' + id).then(() => {
            console.log('bye bye')
            // para atualizar a tela e tirar o elemento excluido
            getAreas()
        })
    }

    function getLinhas(){
        // map = função que percorre todo o array
        return areas.map((area) => {
            return (
                <tr>
                    <td>{area._id}</td>
                    <td>{area.descricao}</td>
                    <td>
                        <button onClick={() => {
                            excluirArea(area._id)
                            }}>Excluir</button>
                        <button>Editar</button>
                    </td>
                </tr>
            )
        })
    }

    function getTabela(){
        return(
            <table>
                <tr>
                    <th>ID</th>
                    <th>Descrição</th>
                </tr>
                {getLinhas()}
            </table>
        )
    }

    return (
        <div>
            <h1>Formulário CRUD</h1>
            <form>
                <label for="name">Nome</label>
                <input type="text" id="name" name="name" />
                <label for="cpf">CPF</label>
                <input type="text" id="cpf" name="cpf" multiple />
                <button>Salvar</button>
            </form>
            {getTabela()}
        </div>
    );
}

export default Cadastros;
