<template>
	<div
		class="message-form"
	>
		<textarea
			v-model="currentText"
			:placeholder="'new Tweet here.'"
			rows="2"
		>
		</textarea>

		<button
			v-text="'send'"
			@click="postTweet"
		>
		</button>
	</div>
</template>

<script>
	import * as tweetApi from '../../Api/tweetApi.js'

	export default {
		name: "MessageForm",
		props: {
			userId: {
				default: null,
				type: String
			}
		},
		data () {
			return {
				currentText: ''
			}
		},
		methods: {
			postTweet () {
				tweetApi.postTweet({
					userId: this.userId,
					message: this.currentText
				}).then(() => {
					this.$emit('reloadTweets')
				})
			}
		}
	}
</script>

<style lang="scss" scoped>

	.message-form {
		display: flex;
		flex-direction: column;
		align-items: center;

		textarea {
			align-self: flex-start;
			border: 1px solid #58585B;
			border-radius: 2px;
			color: #58585B;
			font-size: 13px;
			font-weight: 400;
			min-height: 50px;
			min-width: 100px;
			max-width: 100%;
			padding: 10px;
			resize: none;
			text-indent: 0;
			line-height: 20px;
			width: 100%;

			&::placeholder {
				color: #afafaf;
			}

			&:focus {
				border-color: #00bbd5;
			}

			&:disabled {
				resize: none;
				background-color: white;
				color: #afafaf;
				border-color: #dddddd;
			}

			&::placeholder,
			&::-webkit-input-placeholder,
			&::-moz-placeholder,
			&:-ms-input-placeholder,
			&:-moz-placeholder {
				color: #dddddd;
			}
		}

		button {
			align-self: flex-end;
			margin: 5px;
			cursor: pointer;
		}
	}

</style>