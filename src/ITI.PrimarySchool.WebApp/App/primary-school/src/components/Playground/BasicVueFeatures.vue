<template>
    <div class="basic-features">
        <section>
            {{ title }}
        </section>

        <section>
            <input type="text" v-model="title">
            <button type="button" @click="changeTitle()">Change title</button>
        </section>

        <section>
            <div v-if="showMessage">
                Secret message!
            </div>

            <button type="button" v-if="!showMessage" @click="showMessage = true">Show secret message!</button>
            <button type="button" v-if="showMessage" @click="showMessage = false">Hide secret message!</button>
        </section>

        <section>
            All fruits:

            <ul>
                <li v-for="(fruit, idx) of fruits" :key="idx">
                    {{ fruit }}
                </li>
            </ul>
        </section>

        <section>
            Fruits not orange:

            <ul>
                <li v-for="(fruit, idx) of fruitsNotOrange" :key="idx">
                    {{ fruit }}
                </li>
            </ul>
        </section>

        <section>
            {{ counter }}
            <button type="button" @click="counter += 1">Increment</button>
            <div v-if="isLessThanTen">Number is less than 10</div>
        </section>
    </div>
</template>

<script>
export default {
    data() {
        return {
            title: 'My title',
            showMessage: false,
            fruits: ['apple', 'orange', 'pear'],
            counter: 0,
            message: 'Here my message'
        }
    },

    methods: {
        changeTitle() {
            this.title = 'New title'
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

<style lang="scss" scoped>
    .basic-features {
        > section {
            margin-bottom: 25px;
        }
    }
</style>