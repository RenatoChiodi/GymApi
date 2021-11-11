export default class FotoService {

    constructor(resource) {

        this._resource = resource('api/People{/id}');
    } 

    lista() {

        return this._resource
            .query()
            .then(res => res.json(), err => {
                console.log(err);
                throw new Error('Não foi possível obter os alunos');
            });
    }  

    cadastra(aluno) {
        if(aluno.id) {
            return this._resource
                .update({ id: aluno.id}, aluno);
        } else {
            return this._resource
                .save(aluno);    
        }

    }
    
    apaga(id) {
        return this._resource
            .delete({ id })
            .then(null, err => {
                console.log(err);
                throw new Error('Não foi possível remover o aluno');
            })
    }

    busca(id) {

        return this._resource
            .get({ id })
            .then(res => res.json());
    }

}