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
                    md="6"
                  >
                    <datepicker 
                      v-model="editedItem.date"
                      label="Data"
                    ></datepicker>
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
            <v-card-title class="text-h6">Tem certeza que deseja apagar este aluno?</v-card-title>
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
     <template v-slot:item.actions="{ item }">
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
import Datepicker from 'vuejs-datepicker';

export default defineComponent({
  setup() {
    
  },
  components: {
    Datepicker
  },
  data() {
    return {
      dialog: false,
      dialogDelete: false,
      titulo: 'Alunos', 
      alunos: [],
      editedIndex: -1,
      editedItem: {
        id: 0,
        date: null,
      },
      defaultItem: {
       id: 0,
        date: null,
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
        this.editedIndex = item
        this.editedItem = Object.assign({}, item)
        this.dialogDelete = true
      },

      deleteItemConfirm () {
       this.service.apaga(this.editedIndex.id)
        .then(()=> {
          let indice = this.alunos.indexOf(this.editedIndex);
          this.alunos.splice(indice, 1);
          this.mensagem = 'Avaliação removida com sucesso';
        }, err => {
          this.mensagem = err.message;
        });
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
          console.log(this.editedItem.date)
        // if (this.editedIndex > -1) {
        //   Object.assign(this.alunos[this.editedIndex], this.editedItem)
        // } else {
        //   this.alunos.push(this.editedItem)
        // }
        // this.grava()
        // this.close()
      },

      grava () {
              this.service
              .cadastra(this.editedItem)
              .then(() => {
            }, err => console.log(err));
      },
},
  computed: {
    formTitle () {
        return this.editedIndex === -1 ? 'Novo Avaliação' : 'Editar Avaliação'
      },
          
      headers () {
        return [
          { text: 'Id', value: 'id' },
          {
            text: 'Nome',
            align: 'start',
            sortable: false,
            value: 'name',
          },
          { text: 'Sobrenome', value: 'lastName' },
          { text: 'CPF', value: 'cpf' },
          { text: 'E-mail', value: 'email' },
          { text: 'Actions', value: 'actions', sortable: false },
        ]
      },
    },
})
</script>
