<template>
	<div
		class="task2-page"
	>
		<div class="task-2-form">
			<input
				v-model="task2Value"
				placeholder="task 2"
			>
			<p>your value inverted: {{ task2Inverted }}</p>
		</div>

	</div>
</template>

<script>
	export default {
		name: "Task2Page",
		data () {
			return {
				task2Value: ''
			}
		},
		computed: {
			task2Inverted () {
				let result = ''

				if (this.task2Value.length > 0) {
					result = this.invertString(this.task2Value)
				}

				return result
			}
		},
		methods: {
			invertString (inputValue) {
				let result = inputValue.split('').reverse().join('')
				console.log(result)
				return result
			}
		}
	}
</script>

<style lang="scss" scoped>

	.task2-page {
		padding: 40px;
	}

</style>