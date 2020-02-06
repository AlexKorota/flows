using Microsoft.EntityFrameworkCore.Migrations;

namespace flows.Data.Migrations
{
    public partial class removeownerIdFromExpensesGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Budget_Users_OwnerId",
                table: "Budget");

            migrationBuilder.DropForeignKey(
                name: "FK_Expense_Budget_BudgetId",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_Expense_ExpensesGroup_ExpensesGroupId",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_Expense_Users_UserId",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpensesGroup_Budget_BudgetId",
                table: "ExpensesGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpensesGroup_Users_OwnerId",
                table: "ExpensesGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpensesGroup",
                table: "ExpensesGroup");

            migrationBuilder.DropIndex(
                name: "IX_ExpensesGroup_OwnerId",
                table: "ExpensesGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expense",
                table: "Expense");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Budget",
                table: "Budget");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "ExpensesGroup");

            migrationBuilder.RenameTable(
                name: "ExpensesGroup",
                newName: "ExpensesGroups");

            migrationBuilder.RenameTable(
                name: "Expense",
                newName: "Expenses");

            migrationBuilder.RenameTable(
                name: "Budget",
                newName: "Budgets");

            migrationBuilder.RenameIndex(
                name: "IX_ExpensesGroup_BudgetId",
                table: "ExpensesGroups",
                newName: "IX_ExpensesGroups_BudgetId");

            migrationBuilder.RenameIndex(
                name: "IX_Expense_UserId",
                table: "Expenses",
                newName: "IX_Expenses_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Expense_ExpensesGroupId",
                table: "Expenses",
                newName: "IX_Expenses_ExpensesGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Expense_BudgetId",
                table: "Expenses",
                newName: "IX_Expenses_BudgetId");

            migrationBuilder.RenameIndex(
                name: "IX_Budget_OwnerId",
                table: "Budgets",
                newName: "IX_Budgets_OwnerId");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ExpensesGroups",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpensesGroups",
                table: "ExpensesGroups",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expenses",
                table: "Expenses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Budgets",
                table: "Budgets",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ExpensesGroups_UserId",
                table: "ExpensesGroups",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Budgets_Users_OwnerId",
                table: "Budgets",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Budgets_BudgetId",
                table: "Expenses",
                column: "BudgetId",
                principalTable: "Budgets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_ExpensesGroups_ExpensesGroupId",
                table: "Expenses",
                column: "ExpensesGroupId",
                principalTable: "ExpensesGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Users_UserId",
                table: "Expenses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpensesGroups_Budgets_BudgetId",
                table: "ExpensesGroups",
                column: "BudgetId",
                principalTable: "Budgets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpensesGroups_Users_UserId",
                table: "ExpensesGroups",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Budgets_Users_OwnerId",
                table: "Budgets");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Budgets_BudgetId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_ExpensesGroups_ExpensesGroupId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Users_UserId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpensesGroups_Budgets_BudgetId",
                table: "ExpensesGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpensesGroups_Users_UserId",
                table: "ExpensesGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpensesGroups",
                table: "ExpensesGroups");

            migrationBuilder.DropIndex(
                name: "IX_ExpensesGroups_UserId",
                table: "ExpensesGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expenses",
                table: "Expenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Budgets",
                table: "Budgets");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ExpensesGroups");

            migrationBuilder.RenameTable(
                name: "ExpensesGroups",
                newName: "ExpensesGroup");

            migrationBuilder.RenameTable(
                name: "Expenses",
                newName: "Expense");

            migrationBuilder.RenameTable(
                name: "Budgets",
                newName: "Budget");

            migrationBuilder.RenameIndex(
                name: "IX_ExpensesGroups_BudgetId",
                table: "ExpensesGroup",
                newName: "IX_ExpensesGroup_BudgetId");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_UserId",
                table: "Expense",
                newName: "IX_Expense_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_ExpensesGroupId",
                table: "Expense",
                newName: "IX_Expense_ExpensesGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_BudgetId",
                table: "Expense",
                newName: "IX_Expense_BudgetId");

            migrationBuilder.RenameIndex(
                name: "IX_Budgets_OwnerId",
                table: "Budget",
                newName: "IX_Budget_OwnerId");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "ExpensesGroup",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpensesGroup",
                table: "ExpensesGroup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expense",
                table: "Expense",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Budget",
                table: "Budget",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ExpensesGroup_OwnerId",
                table: "ExpensesGroup",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Budget_Users_OwnerId",
                table: "Budget",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_Budget_BudgetId",
                table: "Expense",
                column: "BudgetId",
                principalTable: "Budget",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_ExpensesGroup_ExpensesGroupId",
                table: "Expense",
                column: "ExpensesGroupId",
                principalTable: "ExpensesGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_Users_UserId",
                table: "Expense",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpensesGroup_Budget_BudgetId",
                table: "ExpensesGroup",
                column: "BudgetId",
                principalTable: "Budget",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpensesGroup_Users_OwnerId",
                table: "ExpensesGroup",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
