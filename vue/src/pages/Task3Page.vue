<template>
	<div
		class="task3-page"
	>
		<form
			class="task-3-form"
			@submit="checkForm"
			method="post"
		>
			<p
				v-for="(inputData, index) in formModel"
				:key="index"
			>
				<label
					:for="inputData.name"
					v-text="inputData.label"
				>
				</label>
				<input
					v-model="inputData.value"
					:type="inputData.type"
					:name="inputData.name"
					:placeholder="inputData.placeHolder"
				>
				<span
					v-if="inputData.errorText"
					v-text="inputData.errorText"
				>
				</span>
			</p>

			<p
				class="error-list"
				v-if="hasErrors"
			>
				<b>Please correct the following error(s):</b>
				<ul>
					<li
						v-for="(errorValue, errorIndex) in errorList"
						:key="errorIndex"
						v-text="errorValue"
					>
					</li>
				</ul>
			</p>

			<p>
				<input
					type="submit"
					value="Submit"
				>
			</p>
		</form>

	</div>
</template>

<script>
	import Vue from 'vue'

	export default {
		name: "Task3Page",
		data () {
			return {
				accountData: {
					emailValue: '',
					oldPw: '0000',
				},
				formModel: [
					{
						label: 'email: ',
						name: 'email',
						type: 'text',
						placeHolder: 'email',
						value: ''
					},
					{
						label: 'old password: ',
						name: 'oldPassword',
						type: 'password',
						placeHolder: 'old password',
						value: ''
					},
					{
						label: 'new password: ',
						name: 'newPassword',
						type: 'password',
						placeHolder: 'password',
						value: ''
					},
					{
						label: 'confirm password: ',
						name: 'confirmPassword',
						type: 'password',
						placeHolder: 'confirm new password',
						value: ''
					}
				],
				errors: []
			}
		},
		computed: {
			errorList () {
				return this.errors
			},
			hasErrors () {
				return this.errors.length > 0
			}
		},
		methods: {
			compareValues (value1, value2) {
				return value1 === value2
			},
			checkForm (e) {
				e.preventDefault()

				let errorData = []

				let emailValid = this.validateEmail()
				if (!emailValid) {
					errorData.push('Email required.')
				}

				let oldPwValid = this.validateOldPw()
				// this one should be validated silently to prevent hijacking
				if (!oldPwValid) {
					errorData.push('Old password required.')
				}

				let newPwValid = this.validateNewPw()
				if (!newPwValid) {
					errorData.push('Confirm the new password.')
				}

				Vue.set(this, 'errors', errorData)
			},
			validateEmail () {
				return this.formModel[0].value.length > 0
			},
			validateOldPw () {
				return (this.formModel[1].value.length > 0 &&
					this.compareValues(this.accountData.oldPw, this.formModel[1].value)
				)
			},
			validateNewPw () {
				return (this.formModel[2].value.length > 0 &&
					this.compareValues(this.formModel[2].value, this.formModel[3].value)
				)
			}
		}
	}
</script>

<style lang="scss" scoped>

	.task3-page {
		padding: 40px;

		.task-3-form{
			display: flex;
			flex-direction: column;
			align-items: flex-start;

			input {
				width: 240px;
			}

			.error-list {
				text-align: left;
				color: red;
				font-size: 10px;
			}
		}
	}

</style>