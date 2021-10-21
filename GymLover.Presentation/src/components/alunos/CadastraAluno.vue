<script>
//import { defineComponent } from '@vue/composition-api'

export default defineComponent({
  setup() {
  },
   data() {

      return {

          aluno: new Aluno(),
          id: this.$route.params.id
      }
  },
  methods: {

      grava() {
          this.$validator
          .validateAll()
          .then(success =>{
            if(success) {
              this.service
              .cadastra(this.aluno)
              .then(() => {
              if(this.id) this.$router.push({ name: 'home' });
              this.aluno = new Foto();
            }, err => console.log(err));
            }
          });
      }
  },
  created() {

      this.service = new FotoService(this.$resource);

      if(this.id) {
        this.service
          .busca(this.id)
          .then(aluno => this.aluno = aluno);
      }
  }
})
</script>
