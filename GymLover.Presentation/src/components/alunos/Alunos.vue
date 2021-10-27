<template>
  <v-data-table
    :headers="headers"
    :items="alunos"
    sort-by="name"
    class="elevation-1"
  >
    <template v-slot:top>
      <v-toolbar flat>
        <v-toolbar-title>Alunos</v-toolbar-title>
        <v-divider
          class="mx-4"
          inset
          vertical
        ></v-divider>
        <v-spacer></v-spacer>
        <v-dialog
          v-model="dialog"
          max-width="500px"
        >
          <template v-slot:activator="{ on, attrs }">
            <v-btn
              color="primary"
              dark
              class="mb-2"
              v-bind="attrs"
              v-on="on"
            >
              Novo
            </v-btn>
          </template>
          <v-card>
            <v-card-title>
              <span class="text-h5">{{ formTitle }}</span>
            </v-card-title>

            <v-card-text>
              <v-container>
                <v-row>
                  <v-col
                    cols="12"
                    sm="6"
                    md="4"
                  >
                    <v-text-field
                      v-model="editedItem.name"
                      label="Name"
                    ></v-text-field>
                  </v-col>
                  <v-col
                    cols="12"
                    sm="6"
                    md="4"
                  >
                    <v-text-field
                      v-model="editedItem.lastName"
                      label="Sobrenome"
                    ></v-text-field>
                  </v-col>
                  <v-col
                    cols="12"
                    sm="6"
                    md="4"
                  >
                    <v-text-field
                      v-model="editedItem.cpf"
                      label="CPF"
                    ></v-text-field>
                  </v-col>
                  <v-col
                    cols="12"
                    sm="6"
                    md="4"
                  >
                    <v-text-field
                      v-model="editedItem.email"
                      label="Email"
                    ></v-text-field>
                  </v-col>
                </v-row>
              </v-container>
            </v-card-text>

            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn
                color="blue darken-1"
                text
                @click="close"
              >
                Cancelar
              </v-btn>
              <v-btn
                color="blue darken-1"
                text
                @click="save"
              >
                Salvar
              </v-btn>
            </v-card-actions>
          </v-card>
        </v-dialog>
        <v-dialog v-model="dialogDelete" max-width="500px">
          <v-card>
            <v-card-title class="text-h5">Tem certeza que deseja apagar este aluno?</v-card-title>
            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn color="blue darken-1" text @click="closeDelete">Cancelar</v-btn>
              <v-btn color="blue darken-1" text @click="deleteItemConfirm">OK</v-btn>
              <v-spacer></v-spacer>
            </v-card-actions>
          </v-card>
        </v-dialog>
      </v-toolbar>
    </template>
     <template v-slot:item="{ item }">
     <v-icon
        small
        class="mr-2"
        @click="editItem(item)"
      >
        mdi-pencil
      </v-icon>
      <v-icon
        small
        @click="deleteItem(item)"
      >
        mdi-delete
      </v-icon>
    </template>  
  </v-data-table>
</template>

<script>
import { defineComponent } from '@vue/composition-api';
import AlunoService from '../../domain/alunos/AlunoService';

export default defineComponent({
  setup() {
    
  },
  data() {
    return {
      dialog: false,
      dialogDelete: false,
      titulo: 'Alunos', 
      alunos: [],
      editedIndex: -1,
      editedItem: {
        name: '',
        lastName: '',
        cpf: '',
        email: '',
      },
      defaultItem: {
        name: '',
        lastName: '',
        cpf: '',
        email: '',
      },
    }
  },
  
  created() {
      this.service = new AlunoService(this.$resource);
      this.service
        .lista()
        .then(alunos => this.alunos = alunos, err => this.mensagem = err.message);
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

   editItem (item) {
        this.editedIndex = this.alunos.indexOf(item)
        this.editedItem = Object.assign({}, item)
        this.dialog = true
      },

      deleteItem (item) {
        this.editedIndex = this.alunos.indexOf(item)
        this.editedItem = Object.assign({}, item)
        this.dialogDelete = true
      },

      deleteItemConfirm () {
        this.alunos.splice(this.editedIndex, 1)
        this.closeDelete()
      },

      close () {
        this.dialog = false
        this.$nextTick(() => {
          this.editedItem = Object.assign({}, this.defaultItem)
          this.editedIndex = -1
        })
      },

      closeDelete () {
        this.dialogDelete = false
        this.$nextTick(() => {
          this.editedItem = Object.assign({}, this.defaultItem)
          this.editedIndex = -1
        })
      },

      save () {
        if (this.editedIndex > -1) {
          Object.assign(this.alunos[this.editedIndex], this.editedItem)
        } else {
          this.alunos.push(this.editedItem)
        }
        this.close()
      },
},
  computed: {
    formTitle () {
        return this.editedIndex === -1 ? 'Novo Aluno' : 'Editar Aluno'
      },
    //   watch: {
    //   dialog (val) {
    //     val || this.close()
    //   },
    //   dialogDelete (val) {
    //     val || this.closeDelete()
    //   },
    // },
    
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
        ]
      },
    },
})
</script>
