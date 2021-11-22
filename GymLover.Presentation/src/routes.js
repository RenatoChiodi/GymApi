import Alunos from './components/alunos/Alunos.vue';
import Home from './views/Home.vue';
import Avaliacao from './components/avaliacao/Avaliacao.vue';


export const routes
=[
  {
    path: '',
    component: Home,
    nome : 'Home'
  },
  {
    path: '/Alunos',
    component: Alunos,
    nome: 'Alunos'
  },
  {
    path: '/Avaliacao',
    component: Avaliacao,
    nome: 'Avaliação'
  }
];
