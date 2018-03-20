<template>
    <section class="jumbotron text-center">
        <div class="container">
            {{ title }}

            <button type="button" @click="changeTitle()">Change title</button>

            <input type="text" v-model="title">

            <div v-if="showAlert">
                Alerte !
            </div>

            <button type="button" @click="showAlert = true">Afficher l'alerte</button>

            <ul>
                <li v-for="fruit of fruits">
                    {{ fruit }}
                </li>
            </ul>

            <div>
                {{ counter }}
                <button type="button" @click="counter += 1">Increment</button>
                <div v-if="isLessThanTen">Le nombre est plus petit que 10</div>
            </div>

            <ul>
                <li v-for="fruit of fruitsNotOrange">
                    {{ fruit }}
                </li>
            </ul>

            <h1 class="jumbotron-heading">Bienvenue sur ITI.PrimarySchool</h1>
            <p class="lead text-muted">Cette application est réalisée à l'aide du framework Vue 2.</p>
            <p>
                <a href="http://vuejs.org/v2/guide/" class="btn btn-primary my-2">Guide Vue 2</a>
                <a href="http://vuejs.org/v2/api/" class="btn btn-secondary my-2">Documentation API Vue 2</a>
            </p>
        </div>
    </section>
</template>

<script>
export default {
    data() {
        return {
            title: 'Mon titre',
            showAlert: false,
            fruits: ['apple', 'orange', 'pear'],
            counter: 0
        }
    },

    methods: {
        changeTitle() {
            this.title = 'Mon nouveau titre'
        },

        resetTitle() {
            this.title = '';
            this.changeTitle();
        }
    },

    computed: {
        isLessThanTen() {
            return this.counter < 10;
        },

        fruitsNotOrange() {
            return this.fruits.filter(x => x != 'orange');
        }
    }
}
</script>

<style lang="scss">

</style>