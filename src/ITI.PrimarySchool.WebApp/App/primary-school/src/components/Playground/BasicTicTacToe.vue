<template>
    <div>
        Player: {{ turn }}
        <button type="button" @click="reset()">Reset</button>

        <br />

        <div class="row" v-for="(row, rowIdx) of grid" :key="rowIdx">
            <button @click="playCell(rowIdx, colIdx)" type="button" class="cell" v-for="(cell, colIdx) of row" :key="colIdx">
                {{ cell }}
            </button>
        </div>
    </div>
</template>

<script>
export default {
    data() {
        return {
            grid: [],
            turn: 'X'
        }
    },

    mounted() {
        this.reset();
    },

    methods: {
        reset() {
            this.turn = 'X';
            this.grid = [
                ['', '', ''],
                ['', '', ''],
                ['', '', '']
            ];
        },

        playCell(rowIdx, colIdx) {
            const row = this.grid[rowIdx];
            const cell = row[colIdx];

            if (cell == '') {
                row.splice(colIdx, 1, this.turn);
                this.changeTurn();
            }
        },

        changeTurn() {
            this.turn = this.turn == 'X' ? 'O' : 'X';
        }
    }
}
</script>

<style lang="scss" scoped>
.row .cell {
  width: 40px;
  height: 40px;
}
</style>