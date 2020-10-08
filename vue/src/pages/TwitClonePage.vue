<template>
	<div
		class="twit-clone-page"
	>
		<tweet
			v-for="(tweetData, index) in tweetList"
			:key="'t' + index"
			:tweet-data="tweetData"
			:user-list="userList"
		>

		</tweet>

	</div>
</template>

<script>
	import Vue from 'vue'

	import * as userApi from '../Api/userApi.js'
	import * as tweetApi from '../Api/tweetApi.js'

	import Tweet from "../components/TwitClone/Tweet";

	export default {
		name: "TwitClonePage",
		components: {
			'tweet': Tweet
		},
		data () {
			return {
				userList: [],
				tweetList: []
			}
		},
		mounted () {
			this.getUsers()
			this.getTweets()
		},
		methods: {
			getUsers () {
				userApi.getAllusers().then(result => {
					Vue.set(this, 'userList', result)
				})
			},
			getTweets () {
				tweetApi.getAllTweets().then(result => {
					Vue.set(this, 'tweetList', result)
				})
			}
		}
	}
</script>

<style lang="scss" scoped>

	.twit-clone-page {
		display: flex;
		flex-direction: column;
		padding: 20px;
	}

</style>