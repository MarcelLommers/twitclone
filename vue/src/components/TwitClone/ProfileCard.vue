<template>
	<div
		class="profile-card"
		@click="goToUser"
	>
		<div
			class="profile-header"
		>
			<label
				class="header-user-link"
				v-text="user.userName"
			>
			</label>
			<label
				class="header-user-email"
				v-text="user.email">
			</label>
		</div>

		<message-form
			:user-id="user.userId"
			@reloadTweets="reloadTweets"
		>
		</message-form>
	</div>
</template>

<script>
	import MessageForm from "./MessageForm";

	export default {
		name: "ProfileCard",
		components: {
			'message-form': MessageForm
		},
		props: {
			user: {
				default: function () {
					return {
					}
				},
				type: Object
			}
		},
		methods: {
			goToUser () {
				if (!this.$route.path.includes(this.user.userId)) {
					this.$router.push({
						name: 'twitCloneUser',
						params: {
							userId: this.user.userId
						}
					})
				}
			},
			reloadTweets () {
				this.$emit('reloadTweets')
			}
		}
	}
</script>

<style lang="scss" scoped>

	.profile-card {
		background-color: #00bbd5;
		border: 1px solid #58585b;
		border-radius: 5px;
		height: 120px;
		margin: 5px;
		text-align: left;
		overflow: hidden;

		-webkit-box-shadow: 3px 2px 22px -4px rgba(0,0,0,0.75);
		-moz-box-shadow: 3px 2px 22px -4px rgba(0,0,0,0.75);
		box-shadow: 3px 2px 22px -4px rgba(0,0,0,0.75);

		.profile-header {
			display: flex;
			color: white;
			padding: 2px 10px;
			height: 25px;
			align-items: center;
			justify-content: space-between;

			.header-user-link {
				font-size: 18px;
			}

			.header-user-email {
				flex: 1 1;
				text-indent: 10px;
				text-align: left;
				font-size: 13px;
			}
		}

		.message-form {
			margin:auto;
			max-width: calc(100% - 20px);
		}
	}


</style>