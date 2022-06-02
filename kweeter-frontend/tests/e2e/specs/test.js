// https://docs.cypress.io/api/table-of-contents
/// <reference types="Cypress" />

describe('My First Test', () => {
  it('Visits the app root url', () => {
    cy.visit('https://kweeter.vercel.app/')
    cy.contains('h3', 'Welcome')
  }),

  it('Login to Kweeter', () => {
    cy.visit('https://kweeter.vercel.app/')
    cy.get('button').contains('Login').click()
  })
})
