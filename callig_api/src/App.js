import logo from './logo.svg';
import React, {useState, useEffect} from 'react';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import {Button, Input, Modal, ModalBody, ModalFooter, ModalHeader } from 'reactstrap'; 
import { Form } from 'reactstrap';
import axios from 'axios';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faSearch } from '@fortawesome/free-solid-svg-icons';

function App() {
  const baseurl ="https://localhost:44328/api/Users";

  //Tabla para mostrar usuarios
 const [data, setData] = useState([]);

//Estado para el modal para editar
const [modalEditar, setModalEditar]=useState(false);

//Estado para el modal
 const [modalInsertar, setModalInsertar]=useState(false);

 //Estado para el modal
 const [modalEliminar, setModalEliminar]=useState(false);

//Abrir el modal
const abrirCerrarModalInsertar=()=>{
  setModalInsertar(!modalInsertar);
}

//Abrir el modal
const abrirCerrarModalEditar=()=>{
  setModalEditar(!modalEditar);
}

//Abrir el modal
const abrirCerrarModalEliminar=()=>{
  setModalEliminar(!modalEliminar);
}

const [userSeleccionado,setUserSeleccionado]= useState({
    id_User:'',
    name:'',
    lastName:'',
    document_Type:'',
    birth_date:'',
    value_to_win:'',
    civil_Status:''
  })

  const handleChange=e=>{
    const {name, value} = e.target;
    setUserSeleccionado({
      ...userSeleccionado,
      [name]:value

    });
    console.log(userSeleccionado);
  }

//Peticion Get (Traer todos los datos del Api)
  const peticionesGet=async()=>{
    await axios.get(baseurl)
    .then(Response =>{
      setData(Response.data);
    }).catch(error =>{
      console.log(error);
    })
  }

//Peticion Post (Api)
const peticionesPost=async()=>{
  userSeleccionado.id_User = parseInt(userSeleccionado.id_User);
  userSeleccionado.value_to_win = parseInt(userSeleccionado.value_to_win);

  await axios.post(baseurl, userSeleccionado)
  .then(Response =>{
    setData(data.concat(Response.data));
    abrirCerrarModalInsertar();
  }).catch(error =>{
    console.log(error);
  })
}


//Peticion Put (Api)
const peticionesPut=async()=>{
  userSeleccionado.id_User = parseInt(userSeleccionado.id_User);
  userSeleccionado.value_to_win = parseInt(userSeleccionado.value_to_win);
  await axios.put(baseurl+"?Id="+userSeleccionado.id_User,userSeleccionado)

  .then(Response =>{
    var respuesta = Response.data;
    var dataAuxiliar= data;
    dataAuxiliar.map(user=>{
    if(user.id_User===userSeleccionado.id_User){
      user.id_User=respuesta.id_User;
      user.name=respuesta.name;
      user.lastName=respuesta.lastName;
      user.document_Type=respuesta.document_Type;
      user.birth_date=respuesta.birth_date;
      user.value_to_win=respuesta.value_to_win;
      user.civil_Status=respuesta.civil_Status;
    }
    })
    abrirCerrarModalEditar();
  }).catch(error =>{
    console.log(error);
  })
}


//Peticion Put (Api)
const peticionesDelete=async()=>{
  await axios.delete(baseurl+"?Id="+userSeleccionado.id_User)
  .then(Response =>{    
    setData(data.filter(user=>user.id_User!==Response.data))
    abrirCerrarModalEliminar();   
    peticionesGet();
  }).catch(error =>{
    console.log(error);
  })
}

const seleccionarUser=(user,caso)=>{
  setUserSeleccionado(user);
  (caso==="Editar")?
  abrirCerrarModalEditar():abrirCerrarModalEliminar();
}
  useEffect(()=>{
    peticionesGet();
  },[])

  return (
    <div className="App">

       <br/>
      <button onClick={()=>abrirCerrarModalInsertar()} className="btn btn-success">Añadir Nuevo Registro</button>
      <br/> 
      <br/>  
      <table className='table table-bordered'>
        <thead>
          <tr>
          <th>Identificacion </th>      
          <th>Nombre</th>          
          <th>Apellido</th>
          <th>Tipo de Documento</th> 
          <th>Fecha de Nacimiento</th> 
          <th>Valor a Ganar</th> 
          <th>Estado Civil </th>      
          <th>Acciones </th>     
          </tr>
        </thead>
        <tbody>
          {data.map(user=>(
              <tr key={user.id_User}>
              <td>{user.id_User}</td>
              <td>{user.name}</td>
              <td>{user.lastName}</td>
              <td>{user.document_Type}</td>
              <td>{user.birth_date}</td>
              <td>{user.value_to_win}</td>
              <td>{user.civil_Status}</td>
              <td>
                <button className='btn btn-primary' onClick={()=>seleccionarUser(user,"Editar")}>Editar</button>{" "}
                <button className='btn btn-danger' onClick={()=>seleccionarUser(user,"Eliminar")}>Eliminar</button>
              </td>
              </tr>
          ))}
        </tbody>
     </table>
          
          <Modal isOpen={modalInsertar}>
            <ModalHeader>Insertar Usuario </ModalHeader>
            <ModalBody>
              <div className='form-group'>
                    <br/>
                    <th>Identificacion:</th>
                    <br/>
                    <input type="text" className='form-control' name='id_User' onChange={handleChange}/>
                    <br/>
                    <th>Nombre:</th>    
                    <br/>
                    <input type="text" className='form-control' name='name'  onChange={handleChange} />
                    <br/>
                    <th>Apellido:</th>    
                    <br/>
                    <input type="text" className='form-control' name='lastName'  onChange={handleChange} />
                    <br/>
                    <th>Tipo de Documento:</th>    
                    <br/>
                    <input type="text" className='form-control' name='document_Type'  onChange={handleChange} />
                    <br/>
                    <th>Fecha de Nacimiento:</th>    
                    <br/>
                    <input type="date" placeholder='AAAA-MM-DD' className='form-control' name='birth_date'  onChange={handleChange} />
                    <br/>
                    <th>Valor a Ganar:</th>    
                    <br/>
                    <input type="text" className='form-control' name='value_to_win'  onChange={handleChange} />
                    <br/>
                    <th>Estado Civil:</th>    
                    <br/>
                    <input type="text" className='form-control' name='civil_Status'  onChange={handleChange} />
              </div>
            </ModalBody>
            <ModalFooter>
              <button className='btn btn-primary' onClick={()=>peticionesPost()} >Guardar</button>
              <button className='btn btn-danger' onClick={()=>abrirCerrarModalInsertar()} >Cancelar</button>
            </ModalFooter>
          </Modal>

  
          <Modal isOpen={modalEditar}>
            <ModalHeader>Editar Usuario </ModalHeader>
            <ModalBody>
              <div className='form-group'>
                    <br/>
                    <th>Identificacion:</th>
                    <br/>
                    <input type="text" className='form-control' name='id_User' readOnly   onChange={handleChange} value={userSeleccionado && userSeleccionado.id_User}/>
                    <br/>
                    <th>Nombre:</th>    
                    <br/>
                    <input type="text" className='form-control' name='name'  onChange={handleChange} value={userSeleccionado && userSeleccionado.name} />
                    <br/>
                    <th>Apellido:</th>    
                    <br/>
                    <input type="text" className='form-control' name='lastName'  onChange={handleChange} value={userSeleccionado && userSeleccionado.lastName} />
                    <br/>
                    <th>Tipo de Documento:</th>    
                    <br/>
                    <input type="text" className='form-control' name='document_Type'  onChange={handleChange} value={userSeleccionado && userSeleccionado.document_Type} />
                    <br/>
                    <th>Fecha de Nacimiento:</th>    
                    <br/>
                    <input type="date" placeholder='AAAA-MM-DD' className='form-control' name='birth_date'  onChange={handleChange} value={userSeleccionado && userSeleccionado.birth_date} />
                    <br/>
                    <th>Valor a Ganar:</th>    
                    <br/>
                    <input type="text" className='form-control' name='value_to_win'  onChange={handleChange} value={userSeleccionado && userSeleccionado.value_to_win} />
                    <br/>
                    <th>Estado Civil:</th>    
                    <br/>
                    <input type="text" className='form-control' name='civil_Status'  onChange={handleChange} value={userSeleccionado && userSeleccionado.civil_Status} />
              </div>
            </ModalBody>
            <ModalFooter>
              <button className='btn btn-primary' onClick={()=>peticionesPut()} >Guardar</button>{" "}
              <button className='btn btn-danger' onClick={()=>abrirCerrarModalEditar()} >Cancelar</button>
            </ModalFooter>
          </Modal>

            <Modal isOpen={modalEliminar}>
              <ModalBody>
                ¿Estas Seguro que Deseas Eliminar Este Usuario? {userSeleccionado && userSeleccionado.name}
              </ModalBody>
              <ModalFooter>
                <button
                 className='btn btn-danger'
                 onClick={()=>peticionesDelete()} 
                >
                  Si
                </button>
                <button 
                className='btn btn-secondary'
                onClick={()=>abrirCerrarModalEliminar()} >
                  No
                </button>
              </ModalFooter>
            </Modal>
         

    </div>
  );
}export default App;
