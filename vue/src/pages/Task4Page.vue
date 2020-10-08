<template>
	<div
		class="task4-page"
	>
		<span
			v-for="(texValue, index) in matrixData"
			:key="index"
			v-text="texValue"
		>
		</span>

		<button
			v-text="'turn left'"
			@click="rotateLeft(matrixData)"
		>
		</button>

		<button
			v-text="'turn right'"
			@click="rotateRight(matrixData)"
		>
		</button>
	</div>
</template>

<script>
	import Vue from 'vue'

	export default {
		name: "Task4Page",
		data () {
			return {
				matrixData: [
					[1,2,3],
					[4,5,6],
					[7,8,9]
				]
			}
		},
		methods: {
			rotateLeft (matrix) {
				const n = matrix.length
				const x = Math.floor(n/ 2)
				const y = n - 1

				for (let i = 0; i < x; i++) {
					for (let j = i; j < y - i; j++) {
						let k = matrix[i][j] // 0,0

						Vue.set(matrix[i], j, matrix[j][y - i])
						Vue.set(matrix[j], y - i, matrix[y - i][y - j])
						Vue.set(matrix[y - i], y - j, matrix[y - j][i])
						Vue.set(matrix[y - j], i,k)
					}
				}
				return matrix
			},
			rotateRight (matrix) {
				const n = matrix.length
				const x = Math.floor(n/ 2)
				const y = n - 1

				for (let i = 0; i < x; i++) {
					for (let j = i; j < y - i; j++) {
						let k = matrix[i][j]

						Vue.set(matrix[i], j, matrix[y - j][i])
						Vue.set(matrix[y - j], i, matrix[y - i][y - j])
						Vue.set(matrix[y - i], y - j, matrix[j][y - i])
						Vue.set(matrix[j], y - i, k)
					}
				}
				return matrix
			}
		}
	}
</script>

<style lang="scss" scoped>

	.task4-page {
		display: flex;
		flex-direction: column;
		padding: 40px;

		span {
			margin-bottom: 3px;
		}
	}

</style>