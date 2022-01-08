<template>
    <div>
        <div>
            <button v-show="show" @click="showInput()" class="btn btnEditar">Editar</button>
            <Titulo :texto="'Aluno: ' + aluno.nome " :btnVoltar="!show" />
        </div>
        
        <table>
            <tbody>
                <tr>
                    <td class="colPequeno">Matrícula:</td>
                    <td>
                        <label>{{ aluno.id }}</label>
                    </td>
                </tr>
                <tr>
                    <td class="colPequeno">Nome:</td>
                    <td>
                        <label v-if="show == true">{{ aluno.nome}}</label>
                        <input v-else v-model="aluno.nome" type="text" />
                    </td>
                </tr>
                <tr>
                    <td class="colPequeno">Sobrenome:</td>
                    <td>
                        <label v-if="show == true">{{ aluno.sobrenome }}</label>
                        <input v-else v-model="aluno.sobrenome" type="text"/>
                    </td>
                </tr>
                <tr>
                    <td class="colPequeno">Data Nascimento:</td>
                    <td>
                        <label v-if="show == true">{{ aluno.dataNasc }}</label>
                        <input v-else v-model="aluno.dataNasc" type="Date"/>
                    </td>
                </tr>
                <tr>
                    <td class="colPequeno">Professor:</td>
                    <td>
                        <label v-if="show == true">{{ aluno.professor.nome }}</label>
                        <select v-else v-model="aluno.professor">
                            <option v-for="(professor, index) in professores" :key="index" :value="professor">
                                {{ professor.nome }}
                            </option>
                        </select>
                    </td>
                </tr>
            </tbody>
        </table>

        <div style="margin-top: 10px">
            <div v-if="!show">
                <button class="btn btnSalvar" @click="Salvar(aluno)">Salvar</button>
                <button class="btn btnCancelar" @click="Cancelar()">Cancelar</button>
            </div>

        </div>
    </div>
</template>

<script>
import Titulo from '../_share/Titulo.vue';
export default {
    components: {
        Titulo
    },
    data(){
        return {
            professores: [],
            aluno: {},
            id: this.$route.params.id,

            show: true
        }
    },

    async created(){
        await fetch('http://localhost:3000/alunos/' + this.id)
          .then(resp => resp.json()).then(aluno => this.aluno = aluno);

        await fetch('http://localhost:3000/professores')
          .then(resp => resp.json())
          .then(professores => { 
            this.professores = professores
        });
    },

    methods: {

        showInput(){
            this.show = !this.show;
        },

        async Salvar(_aluno){
            let aluno = {
                id: _aluno.id,
                nome: _aluno.nome,
                sobrenome: _aluno.sobrenome,
                dataNasc: _aluno.dataNasc,
                professor: _aluno.professor
            }
            
            let dataJson = JSON.stringify(aluno);

            console.log(dataJson)
            /*
            await fetch(`http://localhost:3000/alunos/${aluno.id}`, {
                method: 'PUT',
                headers: { "Content-Type": "application/json" },
                body: dataJson
            })
*/
            this.show = !this.show;
        },

        Cancelar(){
            this.show = !this.show;
        }
    }
}
</script>

<style scoped>

.btnEditar {
    margin-top: 15px;
    float: right;
    background-color: rgb(76, 186, 249);
}

.btnSalvar {
    float: right;
    background-color: rgb(76, 186, 68);
}

.btnCancelar {
    background-color: rgb(249, 186, 98);
}

.colPequeno {
    width: 20%;
}

input, select {
    margin: 0px;
    padding: 5px 10px;
    font-size: 0.9em;
    border-radius: 5px;
    border: 1px solid silver;
    font-family: Montserrat;
    background-color: rgb(245, 245, 245);
    width: 95%;
}

select {
    height: 38px;
    width: 100%;
}

</style>