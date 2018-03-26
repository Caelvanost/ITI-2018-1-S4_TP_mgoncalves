<template>
    <div>
        <div class="mb-4 d-flex justify-content-between">
            <h1>Détails de la classe</h1>

        </div>

        <table class="table table-striped table-hover table-bordered">
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Nom</th>
                    <th>Niveau</th>
                </tr>
            </thead>

            <tbody>
                <tr>
                    <td>{{ viewedclass.classId }}</td>
                    <td>{{ viewedclass.name }}</td>
                    <td>{{ viewedclass.level }}</td>
                </tr>
            </tbody>
        </table>



        <div class="mb-4 d-flex justify-content-between">
            <h2>Professeur :</h2>

        </div>
        <table class="table table-striped table-hover table-bordered">
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Nom</th>
                    <th>Prénom</th>
                    <th>Présence</th>
                </tr>
            </thead>

            <tbody>
                <tr v-if="assignedTeacher.teacherId == null">
                    <td colspan="5" class="text-center">Aucun professeur n'est assigné à cette classe.</td>
                </tr>
                <tr v-else>
                    <td>{{ assignedTeacher.teacherId }}</td>
                    <td>{{ assignedTeacher.lastName }}</td>
                    <td>{{ assignedTeacher.firstName }}</td>
                    <td>{{ displayPresence(assignedTeacher.presence) }}</td>
                </tr>
            </tbody>
        </table>



        <div class="mb-4 d-flex justify-content-between">
            <h2>Élèves :</h2>

        </div>        
        <table class="table table-striped table-hover table-bordered">
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Nom</th>
                    <th>Prénom</th>
                    <th>Date de naissance</th>
                    <th>Login github</th>
                </tr>
            </thead>

            <tbody>
                <tr v-if="studentList.length == 0">
                    <td colspan="5" class="text-center">Il n'y a actuellement aucun élève dans cette classe.</td>
                </tr>

                <tr v-for="i of studentList">
                    <td>{{ i.studentId }}</td>
                    <td>{{ i.lastName }}</td>
                    <td>{{ i.firstName }}</td>
                    <td>{{ new Date(i.birthDate).toLocaleDateString() }}</td>
                    <td>{{ i.gitHubLogin }}</td>
                </tr>
            </tbody>
        </table> 
    </div>
</template>


<script>
import { mapActions } from 'vuex'
import ClassApiService from '../../services/ClassApiService'

export default {
    data() {
        return {
            viewedclass: {},
            id: null,
            assignedTeacher: {},
            studentList: []
        }
    },

    async mounted() {
        this.id = this.$route.params.id;
        this.viewedclass = await ClassApiService.getClassAsync(this.id);
        this.assignedTeacher = await ClassApiService.getAssignedTeacherAsync(this.id);
        this.studentList = await ClassApiService.getStudentListAsync(this.id);
    },

        methods: {
            displayPresence(presence) {
         
                if (presence == true) {
                    return "";
                } else {
                    return "ABS";
                }
            },    
        }
}
</script>