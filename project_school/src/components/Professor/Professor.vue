<template>
  <div>
    <Titulo texto="Professores" />
    <table>
      <thead>
        <th>Cod.</th>
        <th>Nome</th>
        <th>Alunos</th>
      </thead>
      <tbody v-if="professores.length">
        <tr v-for="(professor, index) in professores" :key="index">
          <td class="colPequeno" style="text-align: center; width: 15%;">{{ professor.id }}</td>

          <td style="text-decoration: none">
          <router-link :to="`/alunos/${professor.id}`" tag='td'>
            {{ professor.nome }} {{ professor.sobrenome }}
          </router-link>
          </td>
          <td class="colPequeno" style="text-align: center; width: 10%;">
           {{ professor.qtdAlunos }}
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
import Titulo from "../_share/Titulo.vue";

export default {
    components: {
        Titulo
    },
    data(){
        return {
            professores: [],
            alunos: []
        }
    },
    async created() {
      await fetch('http://localhost:3000/alunos').then(resp => resp.json())
      .then(alunos =>  { 
        this.alunos = alunos
        this.carregaProfessores() 
      });
    },

    methods: {
      
      qtdAlunos(){
        this.professores.forEach((professor, index) => {
          professor = {
            id: professor.id,
            nome: professor.nome,
            qtdAlunos: this.alunos.filter(aluno =>
              aluno.professor.id == professor.id).length
          }
          this.professores[index] = professor;
          console.log('professor', professor);
        });

        this.$forceUpdate();
      },

      async carregaProfessores(){
      await fetch('http://localhost:3000/professores')
          .then(resp => resp.json())
          .then(professores => { 
            this.professores = professores
            this.qtdAlunos()
            });
      }
    }
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