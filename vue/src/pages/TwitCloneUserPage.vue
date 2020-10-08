<template>
	<div
		class="twit-clone-user-page"
	>
		<profile-card
			:user="user"
			@reloadTweets="getTweets"
		>
		</profile-card>

		<div
			class="tweet-history"
		>
			<tweet
				v-for="(tweetData, index) in tweetList"
				:key="index"
				:tweet-data="tweetData"
				:user-list="userList"
				@delete="deleteTweet"
			>
			</tweet>
		</div>

	</div>
</template>

<script>
	import Vue from 'vue'

	import * as userApi from '../Api/userApi.js'
	import * as tweetApi from '../Api/tweetApi.js'

	import ProfileCard from "../components/TwitClone/ProfileCard";
	import Tweet from "../components/TwitClone/Tweet";

	export default {
		name: "TwitCloneUserPage",
		components: {
			'profile-card': ProfileCard,
			'tweet': Tweet
		},
		data () {
			return {
				currentText: '',
				user: {},
				tweetList: []
			}
		},
		mounted () {
			this.getUser()
			this.getTweets()
		},
		computed: {
			userId () {
				return this.$route.params.userId ?? ''
			},
			userList () {
				return [ this.user ]
			}
		},
		methods: {
			getUser () {
				userApi.getUser({
					userId: this.userId
				}).then(result => {
					Vue.set(this, 'user', result)
				})
			},
			getTweets () {
				tweetApi.getAllTweetsByUser({
					userId: this.userId
				}).then(result => {
					Vue.set(this, 'tweetList', result)
				})
			},
			sendTweet () {
				tweetApi.postTweet({
					userId: this.userId,
					message: this.currentText
				}).then(result => {
					Vue.set(this, 'tweetData', result)
				})
			},
			deleteTweet () {
				// tweetApi.deleteTweet({
				// 	tweetId: tweetId
				// })
			}
		}
	}
</script>

<style lang="scss" scoped>

	.twit-clone-user-page {
		display: flex;
		flex-direction: column;
		padding: 20px;

		.tweet-history {
			height: calc(100% - 120px);
		}

	}

</style>