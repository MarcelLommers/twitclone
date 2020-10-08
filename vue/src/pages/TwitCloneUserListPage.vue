<template>
	<div
		class="twit-clone-user-list-page"
	>
		<label
			v-for="(userData, index) in userList"
			:key="'u' + index"
			class="user-label"
			v-text="userData.userName"
			@click="goToUser(userData.userId)"
		>
		</label>
	</div>
</template>

<script>
	import Vue from 'vue'

	import * as userApi from '../Api/userApi.js'

	export default {
		name: "TwitCloneUserListPage",
		data () {
			return {
				userList: []
			}
		},
		mounted () {
			this.getUsers()
		},
		methods: {
			getUsers () {
				userApi.getAllusers().then(result => {
					Vue.set(this, 'userList', result)
				})
			},
			goToUser (userId) {
				this.$router.push({
					name: 'twitCloneUser',
					params: {
						userId: userId
					}
				})
			}
		}
	}
</script>

<style lang="scss" scoped>

	.twit-clone-user-list-page {
		display: flex;
		flex-direction: column;
		padding: 40px;
		align-items: center;
		justify-content: center;

		.user-label {
			background-color: #00bbd5;
			border: 1px solid #58585b;
			border-radius: 5px;
			color: white;
			cursor: pointer;
			display: inline-block;
			padding: 5px 10px;
			margin-bottom: 5px;

			&:hover {
				background: #00aae3;
				color: #eeeeee;
			}
		}
	}

</style>