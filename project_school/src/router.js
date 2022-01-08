import { createRouter, createWebHistory } from 'vue-router'
import Alunos from './components/Aluno/Alunos.vue';
import AlunoDetalhe from './components/Aluno/AlunoDetalhe.vue';
import Professor from './components/Professor/Professor.vue';
import Sobre from './components/Sobre/Sobre.vue';


const routes = [
    {
        path: '/professores',
        name: 'Professores',
        component: Professor
    },

    {
        path: '/alunos/:prof_id',
        name: 'Alunos',
        component: Alunos
    },

    {
        path: '/todosalunos',
        name: 'AlunosAll',
        component: Alunos
    },

    {
        path: '/alunoDetalhe/:id',
        name: 'AlunoDetalhe',
        component: AlunoDetalhe
    },

    {
        path: '/sobre',
        name: 'Sobre',
        component: Sobre
    },
  ]
  
  const router = createRouter({
    history: createWebHistory(process.env.BASE_URL),
    routes
  })

  
  export default router