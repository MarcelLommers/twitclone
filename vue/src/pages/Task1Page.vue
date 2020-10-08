<template>
	<div
		class="task-page"
	>
		<span
			v-for="(texValue, index) in task1Results"
			:key="index"
			v-text="texValue"
		>
		</span>
	</div>
</template>

<script>
	export default {
		name: "Task1Page",
		data () {
			return {
				task1Results: []
			}
		},
		created () {
			this.task1Results = this.task1()
		},
		methods: {
			task1 () {
				let result = []
				let i = 1
				let finalNum = 100

				while (i <= finalNum) {
					let loopResult = i

					if (i % 3 === 0) {
						loopResult = 'Top'
					} else if (i % 5 === 0) {
						loopResult = 'geschenken'
					} else if (i % 15 === 0) {
						loopResult = 'Topgeschenken'
					}
					result.push(loopResult)
					i++
				}

				return result
			}
		}
	}
</script>

<style lang="scss" scoped>

	.task-page {
		display: flex;
		flex-direction: column;
		padding: 40px;

		span {
			margin-bottom: 3px;
		}
	}

</style>