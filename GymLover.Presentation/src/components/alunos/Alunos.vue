<template>
  <div>
    <v-data-table
      :headers="headers"
      :items="alunos"
      item-key="name"
      class="elevation-1"
      :search="search"
      :custom-filter="filterOnlyCapsText"
    >
      <template v-slot:top>
        <v-text-field
          v-model="search"
          label="Procurar"
          class="mx-4"
        ></v-text-field>
      </template>
      <!-- <template v-slot:body.append>
        <tr>
          <td>
            <v-text-field
              v-model="alunos"
              type="number"
              label="Less than"
            ></v-text-field>
          </td>
          <td colspan="4"></td>
        </tr>
      </template> -->
    </v-data-table>
  </div>
</template>

<script>
import { defineComponent } from '@vue/composition-api';
import AlunoService from '../../domain/alunos/AlunoService';

export default defineComponent({
  setup() {
    
  },
  data() {
    return {
      titulo: 'Alunos', 
      alunos: []
    }
  },
  
  methods: {

    remove(aluno) { 
      this.service.apaga(aluno.id)
        .then(()=> {
          let indice = this.alunos.indexOf(aluno);
          this.fotos.splice(indice, 1);
          this.mensagem = 'Aluno removido com sucesso';
        }, err => {
          this.mensagem = err.message;
        });
    },

    filterOnlyCapsText (value, search) {
        return value != null &&
          search != null &&
          typeof value === 'string' &&
          value.toString().toLocaleUpperCase().indexOf(search) !== -1
      },
  },

  created() {
    this.service = new AlunoService(this.$resource);
    this.service
      .lista()
      .then(alunos => this.alunos = alunos, err => this.mensagem = err.message);
  },

  computed: {
      headers () {
        return [
          {
            text: 'Nome',
            align: 'start',
            sortable: false,
            value: 'name',
          },
          { text: 'Sobrenome', value: 'lastName' },
          { text: 'CPF', value: 'cpf' },
          { text: 'E-mail', value: 'email' },
          {value: 'id'}
        ]
      },
    },
})
</script>
