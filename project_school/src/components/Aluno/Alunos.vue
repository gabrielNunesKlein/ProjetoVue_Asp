<template>
  <div>
    <Titulo :texto="profId != undefined ? 'Aluno do professor: ' + professor.nome : 'Todos os alunos'" />
    <div v-if="profId != undefined">
      <input type="text" placeholder="Nome do Aluno" v-model="nome" v-on:keyup.enter="addAluno()">
      <button class="btn btn-input" @click="addAluno()">Adicionar</button>
    </div>
    

    <table>
      <thead>
        <th>Mat.</th>
        <th>Nome</th>
        <th>Opções</th>
      </thead>
      <tbody v-if="alunos.length">
        <tr v-for="(aluno, index) in alunos" :key="index">
          <td class="colPequeno">{{ aluno.id }}</td>
          <td>
            <router-link :to="`/alunoDetalhe/${aluno.id}`" style="text-decoration: none">
              {{ aluno.nome }} {{ aluno.sobrenome }}
            </router-link>
          </td>
          <td class="colPequeno">
            <button class="btn btnDanger" @click="remover(aluno)">Remover</button>
          </td>
        </tr>
      </tbody>
      <tfoot v-else>
        Nenhum Aluno Enconttrado
      </tfoot>
    </table>
  </div>
</template>

<script>
import Titulo from '../_share/Titulo.vue';
export default {
  components: { Titulo },
  name: 'Aluno',
  props: {
  },

  methods: {

    async addAluno(){
      let _aluno = {
        nome: this.nome,
        sobrenome: "",
        professor: {
          id: this.profId,
          nome: this.professor.nome
        }
      }

      let dataJson = JSON.stringify(_aluno);

      await fetch('http://localhost:3000/alunos', {
        method: 'POST',
        headers: { "Content-Type": "application/json" },
        body: dataJson
      })
      .then(resp => resp.json())
      .then(alunoRetornado => {
        this.alunos.push(alunoRetornado);
        this.nome = '';
      })
      
    },

    async remover(aluno){
        await fetch(`http://localhost:3000/alunos/${aluno.id}`, {
        method: 'Delete'
      }).then(() => {
        let indice = this.alunos.indexOf(aluno);
        this.alunos.splice(indice, 1)
      });
    },

    async carregaProfessores(){
      await fetch('http://localhost:3000/professores/' + this.profId)
          .then(resp => resp.json())
          .then(professor => { 
            this.professor = professor
            });
      console.log(this.professor);
      }
  },

  data() {
    return {
      titulo: 'Aluno',
      profId: this.$route.params.prof_id,
      professor: {},
      nome: '',
      alunos: []
    }
  },

  async created() {
    if(this.profId){
      this.carregaProfessores();
      await fetch('http://localhost:3000/alunos?professor.id=' + this.profId)
          .then(resp => resp.json()).then(alunos => this.alunos = alunos);
    } else {
      await fetch('http://localhost:3000/alunos').then(resp => resp.json()).then(alunos => this.alunos = alunos);
    }
  },
}
</script>

<style scoped>

input {
  width: calc(100% - 195px);
  border: 0;
  padding: 20px;
  font-size: 1.3em;
  color: #687f7f;
  display: inline;
}

.btn-input {
  width: 150px;
  border: 0px;
  padding: 20px;
  font-size: 1.3em;
  display: inline;
  background: rgb(116, 155, 155);
}

.btn-input:hover {
  padding: 20px;
  margin: 0px;
  border: 0px;
}
</style>
