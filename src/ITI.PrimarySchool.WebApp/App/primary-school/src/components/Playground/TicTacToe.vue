<template>
    <div class="tictactoe">
        <div class="header">
            <h2>
                Playing:
                <span class="badge badge-primary">{{ turn }}</span>
            </h2>

            <div class="alert alert-success" role="alert" v-if="winner">
                <b>{{ turn }}</b> wins!
            </div>

            <button type="button" class="btn btn-secondary btn-sm" @click="resetGrid()">Reset</button>
        </div>

        <div class="grid">
            <div class="row" v-for="(row, rowIdx) in grid" :key="rowIdx">
                <button class="cell" :class="{ 'highlight': isCellInWinningCombination(rowIdx, colIdx) }" v-for="(cell, colIdx) in row" :key="colIdx" @click="setCell(rowIdx, colIdx)">{{ cell }}</button>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    props: {
        size: {
            type: Number,
            required: false,
            default: 3
        }
    },

    data() {
        return {
            grid: [],
            turn: 'X',
            winningCombination: [],
            winner: null
        }
    },

    mounted() {
        this.resetGrid();
    },

    methods: {
        resetGrid() {
            const grid = [];

            // Rows
            for (let i = 0; i < this.size; i++) {
                const row = [];

                // Cells
                for (let j = 0; j < this.size; j++) {
                    row.push('');
                }

                grid.push(row);
            }

            // OR: 
            // const grid = Array(3).fill([]).map(row => Array(3).fill(''));

            this.winner = null;
            this.winningCombination = [];
            this.turn = 'X';
            this.grid = grid;
        },

        changeTurn() {
            const winningCombination = this.hasWinningCombination();

            if (!winningCombination) {
                this.turn = this.turn == 'X' ? 'O' : 'X';
            }
            else {
                this.winner = this.turn;
                this.winningCombination = winningCombination;
            }
        },

        setCell(rowIdx, colIdx) {
            const row = this.grid[rowIdx];
            const cell = row[colIdx];

            if (cell == '') {
                // see: https://vuejs.org/v2/guide/list.html#Array-Change-Detection
                row.splice(colIdx, 1, this.turn);

                this.changeTurn();
            }
        },

        isCellInWinningCombination(rowIdx, colIdx) {
            return this.winningCombination.find(x => x.rowIdx == rowIdx && x.colIdx == colIdx);
        },

        hasWinningCombination() {
            let combination = [];

            const checkCell = (rowIdx, colIdx) => {
                const cell = this.grid[rowIdx][colIdx];
                if (cell == '') return;

                const last = combination[combination.length - 1];
                if (!last || last.cell == cell) {
                    combination.push({
                        rowIdx,
                        colIdx,
                        cell
                    });
                }
            }

            // Rows
            for (let rowIdx = 0; rowIdx < this.size; rowIdx++) {
                for (let colIdx = 0; colIdx < this.size; colIdx++) {
                    checkCell(rowIdx, colIdx);
                }

                if (combination.length == this.size) return combination;
                combination = [];
            }

            // Cols
            for (let colIdx = 0; colIdx < this.size; colIdx++) {
                for (let rowIdx = 0; rowIdx < this.size; rowIdx++) {
                    checkCell(rowIdx, colIdx);
                }

                if (combination.length == this.size) return combination;
                combination = [];
            }

            // Diagonals
            const rowIdxDiagonals = [
                (idx) => idx,
                (idx) => this.size - 1 - idx
            ]

            for (let rowIdxGetter of rowIdxDiagonals) {
                for (let i = 0; i < this.size; i++) {
                    checkCell(rowIdxGetter(i), i);
                }

                if (combination.length == this.size) return combination;
                combination = [];
            }
        }
    },

    computed: {

    }
}
</script>

<style lang="scss" scoped>
.tictactoe {
  text-align: center;

  .header {
    h2 {
      margin-bottom: 10px;
    }
  }

  .grid {
    margin-top: 25px;
    display: inline-block;

    .row {
      .cell {
        width: 60px;
        height: 60px;
        background: none;
        border: 1px solid grey;
        color: grey;
        transition: background 0.2s, color 0.2s;
        outline: none;
        font-size: 30px;

        &:hover {
          background: lightgray;
        }

        &.highlight {
          background: lightgreen;

          &:hover {
            background: green;
            color: white;
          }
        }

        &:first-child {
          border-left: none;
        }

        &:last-child {
          border-right: none;
        }
      }

      &:first-child {
        .cell {
          border-top: none;
        }
      }

      &:last-child {
        .cell {
          border-bottom: none;
        }
      }
    }
  }
}
</style>